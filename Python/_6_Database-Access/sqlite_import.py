import sys
import sqlite3

from sales import load_sale_data
from catalog import load_catalog_data


def main():
    if len(sys.argv) < 3:
        print("Usage: {} <catalog-file.csv> <sales-file.csv> <output.db>".format(sys.argv[0]))
        return 2

    catalog = load_catalog_data(sys.argv[1])
    sales = load_sale_data(sys.argv[2])

    db_filename = sys.argv[3]
    try:
        with sqlite3.connect(db_filename) as connection:
            create_tables(connection)
            print("Table operations complete.")
            import_catalog_into_db(catalog, connection)
            import_sales_into_db(sales, connection)
            print("Data import successful.")
    except Exception as e:
        print(str(e))


def create_tables(connection):
    cursor = connection.cursor()

    cursor.execute("""
        CREATE TABLE IF NOT EXISTS sales (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            catalog_id INTEGER NOT NULL,
            country VARCHAR (3),
            city_name VARCHAR (60),
            sold_on TEXT,
            price NUMERIC,
            FOREIGN KEY (catalog_id) REFERENCES catalog(id)
        );
    """)

    cursor.execute("""
       CREATE TABLE IF NOT EXISTS catalog (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            item_id VARCHAR (200) UNIQUE,
            category VARCHAR (200)
        );
    """)


def import_catalog_into_db(catalog, connection):
    cursor = connection.cursor()
    sql = 'insert or replace into catalog (item_id, category) values (?, ?)'

    for catalog_item in catalog.values():
        cursor.execute(sql, [catalog_item.item_id, catalog_item.category_name])


def import_sales_into_db(sales, connection):
    cursor = connection.cursor()
    sql = """
        insert into sales (catalog_id, country, city_name, sold_on, price)
        values ((select id from catalog where item_id = ?), ?, ?, ?, ?)
    """

    for sale in sales:
        data = [sale.item_id, sale.country, sale.city, sale.sold_on, float(sale.price)]
        cursor.execute(sql, data)


if __name__ == '__main__':
    main()
