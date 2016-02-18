exchange_filename = input()
amounts_filename = input()

rates = {}

with open(exchange_filename, 'r', encoding='utf-8') as file:
    for line in file.readlines():
        if line:
            parts = line.strip().split(' ')
            rates[parts[0]] = float(parts[1])

with open(amounts_filename, 'r', encoding='utf-8') as file:
    for line in file.readlines():
        if line:
            parts = line.strip().split(' ')
            value = round(float(parts[0]) / rates[parts[1]], 2)
            print('{0:.2f}'.format(value))
