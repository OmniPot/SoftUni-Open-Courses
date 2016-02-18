import csv

import iso8601
from decimal import Decimal
from datetime import datetime, timezone


class SalesItem:
    def __init__(self, item_id, country, city, sold_on, price):
        self.item_id = str(item_id)
        self.country = str(country)
        self.city = str(city)

        self.sold_on = sold_on if isinstance(sold_on, datetime) else iso8601.parse_date(sold_on)
        if self.sold_on.tzinfo is None:
            raise ValueError("Naive datetime objects not supported")
        else:
            self.sold_on = self.sold_on.astimezone(timezone.utc)

        self.price = price if isinstance(price, Decimal) else Decimal(price)

    def __repr__(self):
        return "Item: " + str(self.__dict__)


def load_sale_data(filename):
    with open(filename) as file:
        sales = [
            SalesItem(
                item_id = sales_row[0],
                country = sales_row[1],
                city = sales_row[2],
                sold_on = sales_row[3],
                price = sales_row[4]
            ) for sales_row in csv.reader(file)
        ]
        return sales
