FILENAME = '../catalog_sample.csv'

# FILENAME = '../catalog_full.csv'


def parse_catalog(file_name):
    with open(file_name) as file:
        result = {}
        for index, line in enumerate(file):
            values = line.strip().split(',')
            if values and values[-1] and values[-2] and len(values) != 7:
                raise AttributeError('Invalid catalog line values!', index, line)

            if values[-2] not in result:
                result[values[-2]] = list()

            result[values[-2]].append(float(values[-1]))

        return result

parsed_data = parse_catalog(FILENAME)
if len(parsed_data) > 0:
    print('Average prices for categories:')
    for i, j in sorted(parsed_data.items()):
        print('  {}: {:.2f}'.format(i, sum(j) / len(j)))
else:
    print('Empty list!')
