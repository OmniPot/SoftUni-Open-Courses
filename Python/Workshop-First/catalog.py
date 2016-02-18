import csv


class CatalogItem:
    def __init__(self, item_id, category_name):
        self.item_id = str(item_id)
        self.category_name = str(category_name)

    def __repr__(self):
        return "{}: {}".format(self.__class__.__name__, str(self.__dict__))


def load_catalog_data(filename):
    with open(filename) as file:
        catalog = {row[0]: CatalogItem(item_id = row[0], category_name = row[5])
                   for row in csv.reader(file)}

        return catalog
