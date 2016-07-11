# Arbeitszeugnis-Generator

## Projektbeschreibung
Mit dem Arbeitszeugnis-Generator erzeugen Sie schnell standardisierte Arbeitszeugnisse.
Der Vorteil im Vergleich zu einem Online-Generator ist, dass Sie Vorlagen für
Fließtexte sowie die Vorlage für das Zeugnis selbst, komplett eigenständig gestalten können.

Dieses Programm ist als [Praktikantenprojekt der BROCKHAUS AG](https://blog.brockhaus-ag.de) entstanden


## Funktionen

#### :open_file_folder: Erzeugen des Zeugnisses
Die von Ihnen eingegebenen Daten zur Person und der Bewertung werden auf eine Word-Vorlage übertragen.
Sie müssen die Vorlage danach nicht mehr bearbeiten, sondern können diese sofort ausdrucken.

#### :package: Nutzung eines angepassten Design-Templates
Das Zeugnis-Template können sie selbst gestalten. Das Template basiert dabei auf der Serienbrief-Funktion von Word.

#### :floppy_disk: Speichern und Laden von Zeugnissen
Die Daten der Zeugnisse werden in XML Dateien gespeichert. So können Sie Zeugnisse immer wieder Laden und z.B. als Vorlage für neue Zeugnisse verwenden.

#### :star: Bewertung der Arbeitsweise mit Schulnoten
Sie können für jede Person individuell bestimmen, in welchen Punkten (z.B. Arbeitsweise, Fachwissen usw.) Sie diese bewerten wollen.
Die Noten werden dann mithilfe von Textvorlagen in Fließtext verwandelt.  

#### :pencil2: Anpassen der Textvorlagen
Sie könne alle Textvorlagen zu den Bewertungskritieren, aus denen der Fließtext ensteht, selber verändern.

#### :pencil: Textanpassung abhängig von dem Geschlecht der Person
Die Textvorlagen, sowie das Word Template, werden beim Generieren so angepasst, dass Wörter wie z.B. 'Herr' zu 'Frau' werden, wenn das
Geschlecht der Person auf weiblich gestellt wird.

| Original   | Groß/Klein beachtet | Ausgetauscht |
| ---------- |:-------------------:| ------------ |
| Er         | :white_check_mark:  | Sie          |
| Ihm        | :white_check_mark:  | Ihr          |
| Seine      | :white_check_mark:  | Ihre         |
| Seinen     | :white_check_mark:  | Ihren        |
| Seiner     | :white_check_mark:  | Ihrer        |
| Herr       | :no_entry_sign:     | Frau         |
| Herrn      | :no_entry_sign:     | Frau         |
| Seinem     | :white_check_mark:  | Ihrem        |
| Arbeiter   | :no_entry_sign:     | Arbeiterin   |
| Praktikant | :no_entry_sign:     | Praktikantin |

##Template
Eine Standardvorlage finden Sie unter Files/Vorlage.docx. Auf diese wird zurückgegriffen, wenn die von Ihnen ausgewählte Vorlage nicht mehr zu finden ist.
Diese Vorlage können Sie benutzen oder Verändern aber bitte nicht entfernen.


## Kompatibilität

Das Ganze ist eine Win Forms Visual Studio Solution, was bedeutet, dass es nur auf Windows ausführbar ist.

Sie benötigen Microsoft Word um alle Features nutzen zu können.

Die Vorlagen für die Zeugnisse müssen im .docx Format vorliegen, damit das Programm diese erkennt.

##Für Entwickler

Benutzte IDE: Visual Studio 2015

Benötigte Referenzen: DocumentFormat.OpenXml

```sh
PM> Install-Package DocumentFormat.OpenXml
```


##Lizenz
Diese Software unterliegt der [GNU General Public License](https://opensource.org/licenses/GPL-3.0).