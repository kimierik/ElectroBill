  tarvitset
   https://git-scm.com/download/win
   

  



  
```bash 
git clone https://github.com/kimierik/ElectroBill.git
```
  
luo tiedoston kansioon jossa olet ja lataa git pohjan siihen. voit siirtyä kansioon " cd ElectroBill " komennolla.
  
```bash 
git checkout -b (nimi)-versio
``` 

luo oman branchin johon voit tehdä muutoksia ja tallentaa niitä ilman että kaikkien muitten versiot muuttuu saman tien
  
  
  
```bash
git add . 
```  
lisää kaikki muokatut tiedot seurantaan


```bash
git commit -m "(patch note)"
``` 

luo patch noten jota pystyme seuraamaan githubista
  
```bash 
git push origin (nimi)-versio
```
  
puskee muokatut tiedostot github pohjaan



JOS OLET TEKEMÄSSÄ MUUTOKSIA, JA POHJASI EI OLE SAMALLA VERSIOLLA KUIN GITHUB VERSIO
  
```bash
git pull
```
  

voit kysyä aina kimiltä  

