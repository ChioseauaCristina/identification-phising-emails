using IdentificationPhishingEmails.Data;
using IdentificationPhishingEmails.Models;
using IronPython.Hosting;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text;

namespace IdentificationPhishingEmails.Features.Commands.AddEmail
{
    public class AddEmailCommandHandler : IRequestHandler<AddEmailCommand, Email>
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;
        public AddEmailCommandHandler(DataContext dataContext, IConfiguration iconfig)
        {
            _dataContext = dataContext;
            _configuration = iconfig;
        }

        public async Task<Email> Handle(AddEmailCommand request, CancellationToken cancellationToken)
        {
            var isAlreadyInDb = await _dataContext.Emails.FirstOrDefaultAsync(e => e.Content == request.NewEmail.Content, cancellationToken);
            if (isAlreadyInDb is not null)
            {
                throw new Exception($"Email with content: {request.NewEmail.Content} already exists!");
            }
            
            Email email = (Email)request.NewEmail;


            string python = @"C:\Program Files\Python312\python.exe";
            string myPythonScript = @"C:\Users\rober\source\repos\IdentificationPhishingEmails\IdentificationPhishingEmails\IdentificationPhishingEmails\PythonScripts\SpamEmailsScript.py";

            // Create a new process start info
            var psi = new ProcessStartInfo
            {
                FileName = python,
                Arguments = $"\"{myPythonScript}\" {email.Content}",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            // Start the process with the info we specified.
            using (var process = Process.Start(psi))
            {
                // Capture the output
                string output = process.StandardOutput.ReadToEnd();

                string error = process.StandardError.ReadToEnd();

                Console.WriteLine("Output:");
                Console.WriteLine(output);
                Console.WriteLine("Error:");
                Console.WriteLine(error);

                process.WaitForExit();
            }

            await _dataContext.Emails.AddAsync(email, cancellationToken);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return email;
        }
    }
}
