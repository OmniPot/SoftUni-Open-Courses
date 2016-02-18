import requests
from decimal import Decimal

TIMEOUT = 5
TARGET_CURRENCY = 'EUR'


def convert_currency(currency_in, currency_out, currency_amount):
    url = 'http://api.fixer.io/latest'
    response = requests.get(url,
                            timeout=TIMEOUT,
                            params={'symbols': '{},{}'.format(currency_in, currency_out)})
    rates = response.json()['rates']

    if currency_in not in rates or currency_out not in rates:
        raise ValueError('Няма информация за валута за някоя от въведените валути!')
    else:
        return currency_amount / Decimal(rates[currency_in]) * Decimal(rates[currency_out])


def accept_input():
    currency_in = input('Въведете код на входна валуте: ').upper()
    if not currency_in:
        raise ValueError('Невалиден код за входна валута!')

    currency_out = input('Въведете код на изходна валута: ').upper()
    if not currency_out:
        raise ValueError('Невалиден код за изходна валута!')

    currency_amount = Decimal(input('Въведете сума за конвертиране: '))
    if not currency_amount:
        raise ValueError('Нвалидна сума за конвертиране!')

    return {'in': currency_in, 'out': currency_out, 'amount': currency_amount}


def main():
    try:
        user_input = accept_input()
        result = convert_currency(user_input['in'], user_input['out'], user_input['amount'])
        print('Равностойност в {0}: {1:.2f}'.format(user_input['out'], result))

    except Exception as e:
        print("Error: {}".format(str(e)))


if __name__ == '__main__':
    main()
