key = input().strip()
text = input().strip()

if key.startswith('-') or key is '' or text.strip() is '':
    print('INVALID INPUT')
else:
    key = int(key)
    first_index = 65
    last_index = 90
    ciphered = []

    for letter in text:
        key_index = key
        current_index = ord(letter)
        if first_index <= current_index <= last_index:
            while key_index is not 0:
                if key < 0:
                    current_index += 1
                else:
                    current_index -= 1

                if current_index < first_index:
                    current_index = last_index

                if current_index > last_index:
                    current_index = first_index

                key_index -= 1

        ciphered.append(chr(current_index))

    print(''.join(ciphered))
