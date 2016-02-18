def is_anagram(str1, str2):
    str1_list = list(str1)
    str1_list.sort()
    str2_list = list(str2)
    str2_list.sort()

    return str1_list == str2_list


filename = input()
input_word = input()

if not filename or not input_word:
    print('INVALID INPUT')
else:
    with open(filename, 'r', encoding='utf-8') as file:
        words = []
        for line in file.readlines():
            words.append(line.strip())

    anagrams = set()
    for word in words:
        if is_anagram(word, input_word) and word != input_word:
            anagrams.add(word)

    if not anagrams:
        print('NO ANAGRAMS')
    else:
        for word in sorted(anagrams):
            print(word)
