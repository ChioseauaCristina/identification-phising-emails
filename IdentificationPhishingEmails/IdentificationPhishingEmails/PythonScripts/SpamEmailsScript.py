import sys
import pandas as pd
from sklearn.feature_extraction.text import CountVectorizer
from sklearn.model_selection import train_test_split
from sklearn.linear_model import LogisticRegression
from sklearn.metrics import accuracy_score, confusion_matrix
from nltk.corpus import stopwords
from nltk.stem import PorterStemmer
import re
import nltk

#run the script with this line first time when you try to run the code
#nltk.download('stopwords') 

df = pd.read_csv(r'C:\Users\rober\source\repos\IdentificationPhishingEmails\IdentificationPhishingEmails\IdentificationPhishingEmails\PythonScripts\spam.csv', header=0, encoding='latin-1')
#print(df.head())

stop_words = set(stopwords.words('english'))

# Pre-processing the data
ps = PorterStemmer()

def clean_text(text):
    text = re.sub('[^a-zA-Z]', ' ', text)
    text = text.lower()
    text = text.split()
    text = [ps.stem(word) for word in text if not word in stop_words]
    text = ' '.join(text)
    return text

# apply the clean_text function to the 'text' column
df['v2'] = df['v2'].apply(clean_text)

cv = CountVectorizer()
X = cv.fit_transform(df['v2']).toarray()
y = df['v1'].values

X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

lr = LogisticRegression()
lr.fit(X_train, y_train)

y_pred = lr.predict(X_test)

acc_score = accuracy_score(y_test, y_pred)
conf_matrix = confusion_matrix(y_test, y_pred)

#print("Accuracy:", acc_score)
#print("Confusion Matrix:\n", conf_matrix)

def predict_email(email):
    cleaned_email = clean_text(email)
    features = cv.transform([cleaned_email]).toarray()
    prediction = lr.predict(features)[0]
    if prediction == "ham":
        print( "Not Spam")
    else:
        print( "Spam")

# Check if an email parameter is provided
if len(sys.argv) > 1:
    email_to_predict = ' '.join(sys.argv[1:])
    predict_email(email_to_predict)
else:
    print("Please provide an email as a command-line argument.")

    print("finish");