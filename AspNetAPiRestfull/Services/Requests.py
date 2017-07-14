import requests

r = requests.get('http://localhost:5100')
print(r.json())