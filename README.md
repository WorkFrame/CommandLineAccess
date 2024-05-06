# CommandLineAccess
Wertet für Desktop-Anwendungen Kommandozeilen-Parameter aus. Wird über AppEnvReader in BasicAppSettings genutzt.
Implementiert IGetStringValue. Minimal-Funktionalität:
Wenn der übergebene Key in der Kommandozeile existiert, wird dieser unverändert zurückggegeben, ansonsten der Default Value.
Ist der übergebene Key numerisch, wird versucht, mit ihm als Index in die Kommandozeilenparameter zu greifen;
Bei Erfolg wird der entsprechende Wert zurückgegeben, ansonsten der Default Value.

## Einsatzbereich

  - Dieses Repository gehört, wie auch alle anderen unter **WorkFrame** liegenden Projekte, ursprünglich zum
   Repository **Vishnu** (https://github.com/VishnuHome/Vishnu), kann aber auch eigenständig für andere Apps verwendet werden.

## Voraussetzungen, Schnellstart, Quellcode und Entwicklung

  - Weitere Ausführungen findest du im Repository [BasicAppSettings](https://github.com/WorkFrame/BasicAppSettings).
