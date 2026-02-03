# Comment l'architecture MVVM limite la propagation des modifications (V1 → V2)

## Principe
Le passage de la version **Console** à la version **WPF** change uniquement la manière dont l'utilisateur interagit avec l'application (la *Vue*).
Grâce à MVVM :

- La **logique métier** (conversion) est dans `UpperCase.Core.Services.TextConverter`.
- Les **règles applicatives** (validation 1..8 caractères, orchestration de la conversion) sont dans `UpperCase.Core.ViewModels.MainViewModel`.
- Les versions Console et WPF ne font que fournir une **Vue** différente.

## Concrètement dans le code
### Ce qui reste inchangé entre V1 et V2
- `UpperCase.Core.Services.*`
- `UpperCase.Core.ViewModels.MainViewModel`

### Ce qui change / s'ajoute pour V2 (WPF)
- Une vue WPF (`MainWindow.xaml`) qui utilise le **data binding** vers le ViewModel.
- Un ViewModel WPF (`MainWindowViewModel`) qui **réutilise** `MainViewModel` et ajoute uniquement `ICommand` (`ConvertCommand`) pour la commande du bouton.
- Une petite infrastructure WPF (`RelayCommand`) pour implémenter `ICommand`.

## Résultat
Pour passer de V1 à V2, aucune modification n'est nécessaire dans la logique de conversion ni dans la validation :
on ajoute une nouvelle Vue WPF et une couche très fine spécifique WPF (commande).

Voir les diagrammes UML dans `docs/uml`.
