# Workshop MVVM — Convertisseur minuscules → majuscules (C#)

Ce dépôt contient **deux versions** d'une application de conversion d'une chaîne de caractères en majuscules, conçues selon une architecture **MVVM** :

- **V1 — Console** : interactions utilisateur via la console
- **V2 — WPF** : interface graphique (WPF) avec saisie, affichage et bouton

La logique métier et le ViewModel principal sont mutualisés dans un projet **UpperCase.Core** afin de limiter la propagation des changements.

## Règles de conversion
- La chaîne saisie doit contenir **entre 1 et 8 caractères**.
- **Seules les lettres** (alphabet) sont converties en majuscules.
- Les lettres déjà en majuscules, chiffres, caractères spéciaux (`&`, `%`, `!`, `*`, etc.) sont **retranscrits sans modification**.

## Structure
- `src/UpperCase.Core` : modèle/service + ViewModel partagé
- `src/UpperCase.ConsoleApp` : version console
- `src/UpperCase.WpfApp` : version WPF (IHM)
- `docs/uml` : diagrammes UML (PlantUML) + commentaire d'architecture

## Compilation / exécution (Visual Studio)
1. Ouvrir `UpperCaseConverter.sln`
2. Choisir le projet de démarrage :
   - `UpperCase.ConsoleApp` pour V1
   - `UpperCase.WpfApp` pour V2
3. Build & Run

> Remarque : la solution cible `.NET 6` (>= .NET Core 3.0 demandé).  
> Si votre environnement impose une autre version, ajustez `TargetFramework` dans les `.csproj`.

## Tests de recette (à reproduire sur V1 et V2)
| # | Chaîne saisie | Chaîne affichée | Attendu |
|---|--------------|-----------------|---------|
| 1 | maison | MAISON | OK |
| 3 | Corse123 | CORSE123 | OK |
| 4 | %&ciel | %&CIEL | OK |
| 5 | !*port | !*PORT | OK |
