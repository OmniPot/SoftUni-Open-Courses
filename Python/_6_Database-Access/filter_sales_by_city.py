import sys
import sqlite3


def main():
    if len(sys.argv) < 2:
        print("Usage: {} <database.db>".format(sys.argv[0]))
        return 2

    city_name = input("Въведете град: ")
    db_filename = sys.argv[1]
    try:
        sales = fetch_sales(city_name, db_filename)
        display_sales(sales, city_name)
    except Exception as e:
        print("Error: {}".format(str(e)))


def fetch_sales(city_name, db_filename):
    with sqlite3.connect(db_filename) as connection:
        cursor = connection.cursor()
        sql = """
            SELECT c.item_id, s.sold_on, s.price
            FROM sales s
            JOIN catalog c ON c.id = s.catalog_id
            WHERE UPPER(s.city_name) = ?
            ORDER BY s.sold_on
        """
        cursor.execute(sql, [city_name.upper()])
        sales = cursor.fetchall()

    return sales


def display_sales(sales, city_name):
    if len(sales):
        print("Намерени са {} продажби в град '{}'".format(len(sales), city_name))
        for sale in sales:
            print("Артикул #: {0:<6} дата/час: {1:<26} сума: {2:<}".format(sale[0], sale[1], sale[2]))
    else:
        print("Няма данни за продажби в град '{}'".format(city_name))


if __name__ == '__main__':
    main()
