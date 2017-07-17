import requests

try:
#   r = requests.get(url, params={'s': thing})
    r = requests.get('http://localhost:5100')
    print(r.status_code)
    print(r.json())
except requests.ConnectionError as e:  # This is the correct syntax
    print (e)