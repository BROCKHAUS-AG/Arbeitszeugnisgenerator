# Arbeitszeugnis-Generator

Mit dem Arbeitszeugnis-Generator erzeugen Sie schnell standardisierte Arbeitszeugnisse.
Der Vorteil im Vergleich zu einem Online-Generator ist, dass Sie Vorlagen f�r 
Flie�texte sowie die Vorlage f�r das Zeugnis selbst, komplett eigenst�ndig gestalten k�nnen.

Dieses Programm ist als [Praktikantenprojekt der BROCKHAUS AG](https://blog.brockhaus-ag.de) entstanden


##Features

####Erzeugen des Zeugnisses als Word-Dokument mit den Daten aus der Eingabemaske
Die von Ihnen eingegebenen Daten zur Person und der Bewertung werden auf eine Word-Vorlage �bertragen.
Sie m�ssen die Vorlage danach nicht mehr bearbeiten, sondern k�nnen diese sofort ausdrucken.
  
####Nutzung eines angepassten Design-Templates
Das Zeugnis-Template k�nnen sie selbst gestalten. Das Template basiert dabei auf der Serienbrief-Funktion von Word.

####Speichern und Laden von Zeugnissen
Die Daten der Zeugnisse werden in XML Dateien gespeichert. So k�nnen Sie Zeugnisse immer wieder Laden und z.B. als Vorlage f�r neue Zeugnisse verwenden.
    
####Bewertung der Arbeitsweise mit Schulnoten
Sie k�nnen f�r jede Person individuell bestimmen, in welchen Punkten (z.B. Arbeitsweise, Fachwissen usw.) Sie diese bewerten wollen.
Die Noten werden dann mithilfe von Textvorlagen in Flie�text verwandelt.  
 
####Anpassen der Textvorlagen
Sie k�nne alle Textvorlagen zu den Bewertungskritieren, aus denen der Flie�text ensteht, selber ver�ndern.

####Textanpassung abh�ngig von dem Geschlecht der Person
Die Textvorlagen, sowie das Word Template, werden beim Generieren so angepasst, dass W�rter wie z.B. 'Herr' zu 'Frau' werden, wenn das 
Geschlecht der Person auf weiblich gestellt wird.

##Template
Eine Standardvorlage finden Sie unter Files/Vorlage.docx. Auf diese wird zur�ckgegriffen, wenn die von Ihnen ausgew�hlte Vorlage nicht mehr zu finden ist.
Diese Vorlage k�nnen Sie benutzen oder Ver�ndern aber bitte nicht entfernen. 


##Kompatibilit�t

Das Ganze ist eine Win Forms Visual Studio Solution, was bedeutet, dass es nur auf Windows ausf�hrbar ist.

Sie ben�tigen Microsoft Word um alle Features nutzen zu k�nnen.

Die Vorlagen f�r die Zeugnisse m�ssen im .docx Format vorliegen, damit das Programm diese erkennt.

##Lizenz
Diese Software unterliegt der [GNU General Public License](https://opensource.org/licenses/GPL-3.0).
