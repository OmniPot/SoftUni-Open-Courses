from datetime import datetime, timezone
from collections import OrderedDict
from urllib.parse import urlencode
import requests

APPID = 'c462599770a7c06739814db47d068226'


def get_weather_info(town):
    url = 'http://api.openweathermap.org/data/2.5/weather'
    params = OrderedDict({'q': town, 'APPID': APPID})
    response = requests.get(url + '?' + urlencode(params))

    return response.json()


def display_weather(weather_info):
    date = datetime.fromtimestamp(weather_info['dt'], tz=timezone.utc)
    date_formated = date.strftime('%Y-%m-%d %H:%M:%S')

    temp = float(weather_info['main']['temp']) - 273.15
    pressure = weather_info['main']['pressure']
    humididty = weather_info['main']['humidity']
    wind = weather_info['wind']['speed']

    printable = """
    Информация към: {0}
    Температура: {1:.1f} C
    Налягане: {2} hPa
    Влажност: {3} %
    Вятър: {4} m/s
""".format(date_formated, temp, pressure, humididty, wind)

    print(printable)


def main():
    town = input('Въведете град: ')

    weather_info = get_weather_info(town)
    display_weather(weather_info)


if __name__ == '__main__':
    main()
