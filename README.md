-sklep/wynajem sprzętu wędkarskiego


1. Mapka z łowiskami + kupowanie zezwoleń

2. Wynajem sprzętu 

3. Zakup sprzętu

4. Panel admina 

5. Mapka z łowiskami 

6. Wynajem Łodzi 

7. System subskrypcji umożliwiający łowienie na różnych łowiskach i w lepszych wersjach możliwość użytkowania łodzi


++++do ustalenia

WSTĘPNY PODZIAŁ STRONY:

-Główna (reprezentatywna, ładna przejrzysta,  prosta)

-Strona tylko do łowisk (mapka z łowiskami z możliwością wybrania, przekierowanie do rezerwacji itd.)

-Strona do sklepu/wynajmu (razem by nie było za tłoczno, analogicznie formularz zakupu/wynajmu)

-Strona subskrypcji (mała, prosta i zgrabna. 3 subskrybcje, waruki się wymyśli)


STRUKTURA BAZY DANYCH:

NA 100% NA TERAZ:
 
-Łowiska

-Sprzęt

-Rezerwację 

-Pozwolenia

-klienci 


relacje:

-klienci 1:n Pozwolenia, rezerwacje, +nie wiem

-łowisko 1:n łódki, sprzęt(tylko te co są na wynajem, może odzzielna tabela)

-łowsika m:n Rezerwację. tutaj 100% pomocnicza

-+++ jeszcze nie wiem

