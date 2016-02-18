haystack = input('Haystack: ')

if haystack:
    needle = input('Needle: ')
    needle_index = haystack.find(needle)

    if needle_index != -1:
        result = haystack[needle_index + len(needle):]
    else:
        result = haystack[0:]

    result.strip()
    output = 'Output: ' + result
else:
    output = 'Haystack cannot be empty!'

print(output)
