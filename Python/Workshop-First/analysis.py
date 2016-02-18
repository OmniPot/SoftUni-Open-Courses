from decimal import Decimal
from collections import Counter


def print_summary(sales):
    if not sales:
        raise ValueError("No sales to display summary for!")

    total_sales_count = len(sales)
    total_sales_amount = Decimal(0)
    sale_timestamp_min = sales[0].sold_on
    sale_timestamp_max = sales[0].sold_on
    for sales_item in sales:
        total_sales_amount += sales_item.price
        if sales_item.sold_on < sale_timestamp_min:
            sale_timestamp_min = sales_item.sold_on
        if sales_item.sold_on > sale_timestamp_max:
            sale_timestamp_max = sales_item.sold_on

    print("Обобщение\n---------")
    print("    Общ брой продажби: {}".format(total_sales_count))
    print("    Общо сума продажби: {}".format(total_sales_amount))
    print("    Средна цена на продажба: {}".format(total_sales_amount / total_sales_count))
    print("    Начало на период на данните: {}".format(sale_timestamp_min))
    print("    Край на период на данните: {}".format(sale_timestamp_max))
    print()


def print_summary_sales_by_category(catalog, sales, categories_to_print = 5):
    sales_by_category = Counter()
    for sales_item in sales:
        item_category = catalog.get(sales_item.item_id, None)
        item_category_name = item_category.category_name
        sales_by_category[item_category_name] += sales_item.price

    print("Сума на продажби по категории\n-----------------------------")
    for category_name, total_amount in sales_by_category.most_common(5):
        print("    {}: {}".format(category_name, total_amount))
    print()


def print_sales_amount_by_city(sales):
    sales_amount_by_city = Counter()
    for sale_item in sales:
        sales_amount_by_city[sale_item.city] += sale_item.price

    print("Сума на продажби по градове\n---------------------------")
    for city_name, total_amount in sales_amount_by_city.most_common(5):
        print("    {}: {}".format(city_name, total_amount))
    print()


def print_sales_amount_by_hour(sales):
    sales_by_hour = Counter()
    for sale_item in sales:
        replaced = sale_item.sold_on.replace(minute = 0, second = 0, microsecond = 0)
        sales_by_hour[replaced] += sale_item.price

    print("Часове с най-голяма сума продажби\n---------------------------------")
    for hour, amount in sales_by_hour.most_common(5):
        print("    {}: {}".format(hour.strftime("%Y-%m-%d %H:%M"), amount))
