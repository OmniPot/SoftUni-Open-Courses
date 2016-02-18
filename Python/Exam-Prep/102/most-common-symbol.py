from collections import Counter

s = input()
most_common_symbol = Counter(s).most_common(1)[0][0]
print(most_common_symbol)
