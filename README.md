# Warszat

## Æwiczenie 1

1. Utwórz klasê `LoanTermShould`
2. Napisz test który zweryfikuje czy `LoanTerm.ToMonths()` zwraca 12.

## Æwiczenie 2

1. W klasie `LoanTermShould` utwórz test który sprawdzi czy propery `Years` jest ustawione na 1.


---

## Æwiczenie 3

1. SprawdŸ czy dwie instancje `LoanTerm` (`ValueObject`) s¹ sobie równe je¿eli wartoœci parametru Years s¹ sobie równe.
2. Zakomentuj metody `Equals()` oraz `GetHashCode` i uruchom jeszcze raz test.

## Æwiczenie 4

1. Porównaj dwie instancje LoanTerm pod k¹tem referencji (`Is.Not.SameAs()`)
2. Utwórz trzeci¹ zmienn¹ wskazuj¹c¹ na referencjê pierwszej (`Is.SameAs`).

## Æwiczenie 5

1. Utwórz porównaj dwie listy stringów utworzone przy pomocy `new List<string>`.
2. Utwórz trzeci¹ zmienn¹ wskazuj¹c¹ na pierwsz¹ listê i je porównaj.

---

## Æwiczenie 6
1. Zmieñ np. metodê `LoanTerm().ToYears` modyfikuj¹c kod tak aby zwróci³ niepoprawn¹ iloœæ miesiêcy.
2. Zedytuj pierwszy test wykorzystuj¹c przeci¹¿on¹ metodê asercji, która wyœwietli customowy komunikat.
3. Uruchom test i zweryfikuj wiadomoœæ w konsoli.


---

## Æwiczenie 7 - Kolekcje
1. Przetestuj metodê `ProductComparer.CompareMonthlyRepayments()`
2. ¯eby utworzyæ instancjê ProductComparer, musisz utworzyæ:
   - listê produktów po¿yczek (`LoanProduct`) - stwórz trzy unikalne
   - now¹ po¿yczkê (`LoanAmount`)
3. Metoda `CompareMonthlyRepayments` zwraca listê i potrzebuje jako parametr warunków: `new LoanTerm(30)` (po¿yczka na 30 lat)
4. SprawdŸ asercj¹ czy lista zwrócona przez `CompareMonthlyRepayments` zwraca tyle samo elementów ile mamy w liœcie LoadProduct (z punktu 2)


## Æwiczenie 8 - Kolekcje
1. Przetestuj metodê `ProductComparer.CompareMonthlyRepayments()`
2. ¯eby utworzyæ instancjê ProductComparer, musisz utworzyæ:
   - listê produktów po¿yczek (`LoanProduct`) - stwórz trzy
   - now¹ po¿yczkê (`LoanAmount`)
3. Metoda `CompareMonthlyRepayments` zwraca listê i potrzebuje jako parametr warunków: `new LoanTerm(30)` (po¿yczka na 30 lat)
4. SprawdŸ asercj¹ czy lista zwrócona przez `CompareMonthlyRepayments` zwraca unikalne elementy


## Æwiczenie 8 - Kolekcje
1. Przetestuj metodê `ProductComparer.CompareMonthlyRepayments()`
2. ¯eby utworzyæ instancjê ProductComparer, musisz utworzyæ:
   - listê produktów po¿yczek (`LoanProduct`) - stwórz trzy
   - now¹ po¿yczkê (`LoanAmount`)
3. Metoda `CompareMonthlyRepayments` zwraca listê i potrzebuje jako parametr warunków: `new LoanTerm(30)` (po¿yczka na 30 lat)
4. SprawdŸ asercj¹ czy lista zwrócona przez `CompareMonthlyRepayments` zwraca odpowiednie wartoœci dla pierwszego elementu



## Æwiczenie 8 - Kolekcje
1. Przetestuj metodê `ProductComparer.CompareMonthlyRepayments()`
2. ¯eby utworzyæ instancjê ProductComparer, musisz utworzyæ:
   - listê produktów po¿yczek (`LoanProduct`) - stwórz trzy
   - now¹ po¿yczkê (`LoanAmount`)
3. Metoda `CompareMonthlyRepayments` zwraca listê i potrzebuje jako parametr warunków: `new LoanTerm(30)` (po¿yczka na 30 lat)
4. SprawdŸ asercj¹ czy lista zwrócona przez `CompareMonthlyRepayments` zwraca odpowiednie wartoœci w pierwszym elemencie (sprawdŸ dok³adnie property `ProductName` oraz `InterestRate`, dla property MonthlyRepayment jest wiêksza ni¿ 0)


---

## Æwiczenie 9 - £apanie wyj¹tków
1. Napisz test który z³apie wyj¹tek z klasy LoanTerm.
2. Dla `LoanTerm(0)` powinniœmy otrzymaæ `ArgumentOutOfRangeException`


---

## Æwiczenie 10 - Inne asercje