from json import load as json_load
from yaml import load as yaml_load

import os


class Loader:
    def __init__(self, file_name):
        if os.access(file_name, os.R_OK) and os.path.isfile(file_name):
            self.file_name = file_name
        else:
            raise ValueError("Inaccessible file '{}'".format(file_name))

    def load(self, file_name) -> list:
        raise NotImplementedError()


class JSONLoader(Loader):
    def load(self, file_name) -> list:
        with open(file_name) as f:
            return json_load(f)


class YAMLLoader(Loader):
    def load(self, file_name) -> list:
        with open(file_name) as f:
            return yaml_load(f)
