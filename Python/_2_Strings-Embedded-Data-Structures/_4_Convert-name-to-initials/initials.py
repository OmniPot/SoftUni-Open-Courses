titles = ['професор', 'проф.', 'доктор', 'д-р', 'доцент', 'доц.', 'Mr.', 'Mrs.']

name = input('Your name: ').strip()
if name is not '':
    upper_titles = map(str.upper, titles)
    output = ''.join(n[0].upper() + '.' if n.upper() not in upper_titles else '' for n in name.split(' '))
else:
    output = 'Name cannot be empty.'

print(output)
