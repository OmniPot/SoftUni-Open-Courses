FILENAME = '../catalog_sample.csv'
# FILENAME = '../catalog_full.csv'

total = 0
count = 0
with open(FILENAME) as f:
    for line in f:
        values = line.split(',')
        if values \
                and values[0] \
                and len(values) == 7:
            total += float(values[-1])
            count += 1

    if count > 0:
        print("Average price in file '{}' is: {:.2f} for {} items.".format(
                FILENAME, total / count, count
        ))
    else:
        print("File {} is empty!".format(FILENAME))
