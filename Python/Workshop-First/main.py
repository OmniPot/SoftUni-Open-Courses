import os
import sys

import analysis
from sales import load_sale_data
from catalog import load_catalog_data

CATALOG_VALUES_PER_LINE = 8
SALE_VALUES_PER_LINE = 5


def _parse_command_line_parameters():
    if len(sys.argv) < 3:
        raise Exception("Provide at least 3 program arguments!")

    for file in sys.argv[1:3]:
        if not os.access(file, os.R_OK) or not os.path.isfile(file):
            raise Exception("Could not read file '{}'".format(file))

    return sys.argv[1:3]


def main():
    try:
        catalog_filename, sales_filename = _parse_command_line_parameters()

        sales = load_sale_data(sales_filename)
        catalog = load_catalog_data(catalog_filename)

        analysis.print_summary(sales)
        analysis.print_summary_sales_by_category(catalog, sales)
        analysis.print_sales_amount_by_city(sales)
        analysis.print_sales_amount_by_hour(sales)

    except Exception as e:
        print("Error: " + str(e))


if __name__ == "__main__":
    sys.exit(main())
