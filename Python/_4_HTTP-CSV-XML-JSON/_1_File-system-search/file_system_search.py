import os
import sys


def find_file(root_dir, filename):
    if os.path.exists(root_dir):
        results = []
        for root, directories, files in os.walk(root_dir):
            if filename in files:
                results.append(os.path.join(root, filename))

        print(len(results), 'results found!')
        for i, result in enumerate(results):
            print(result)
    else:
        print('Search directory does not exist!')

if len(sys.argv) < 3:
    print('Please, provide at least 2 program arguments!')
else:
    find_file(root_dir = sys.argv[1], filename = sys.argv[2])
