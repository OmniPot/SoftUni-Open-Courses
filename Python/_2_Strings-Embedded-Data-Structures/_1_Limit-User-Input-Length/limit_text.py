MAX_LIMIT = 10

text = input('Write something: ')
if len(text) > MAX_LIMIT:
    text = text[:MAX_LIMIT] + '...'

print('Output: ' + text)
