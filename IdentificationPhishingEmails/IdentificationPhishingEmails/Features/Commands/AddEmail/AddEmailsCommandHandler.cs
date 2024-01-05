using IdentificationPhishingEmails.Data;
using IdentificationPhishingEmails.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace IdentificationPhishingEmails.Features.Commands.AddEmail
{
    public class AddEmailsCommandHandler : IRequestHandler<AddEmailsCommand, List<Email>>
    {
        private readonly DataContext _dataContext;

        public AddEmailsCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Email>> Handle(AddEmailsCommand request, CancellationToken cancellationToken)
        { 
            var existingEmailContents = await _dataContext.Emails
                .Where(e => request.NewEmails.Select(ne => ne.Content).Contains(e.Content))
                .Select(e => e.Content)
                .ToListAsync(cancellationToken);

            var duplicateContents = existingEmailContents.Distinct().ToList();

            if (duplicateContents.Any())
            {
                throw new Exception($"Emails with content: {string.Join(", ", duplicateContents)} already exist!");
            }

            var newEmails = new List<Email>();

            foreach (var newEmailDto in request.NewEmails)
            {
                Email email = (Email)newEmailDto;

                string python = @"C:\Program Files\Python312\python.exe";
                string myPythonScript = @"C:\Users\rober\source\repos\IdentificationPhishingEmails\IdentificationPhishingEmails\IdentificationPhishingEmails\PythonScripts\SpamEmailsScript.py";

                var psi = new ProcessStartInfo
                {
                    FileName = python,
                    Arguments = $"\"{myPythonScript}\" {email.Content}",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                using (var process = Process.Start(psi))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    if (output.Equals("No Spam"))
                    {
                        email.IsSpam = false;
                    }
                    else
                    {
                        email.IsSpam = true;
                    }

                    process.WaitForExit();
                }

                newEmails.Add(email);
            }

            _dataContext.Emails.AddRange(newEmails);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return newEmails;
        }
    }
}
