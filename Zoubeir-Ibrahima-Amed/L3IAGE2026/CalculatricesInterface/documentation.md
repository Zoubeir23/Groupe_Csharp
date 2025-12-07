# Documentation de la Calculatrice Scientifique

Ce document fourni une explication détaillée du projet de la calculatrice scientifique, de sa structure à son fonctionnement interne.

## 1. Structure du Projet

Le projet est une application de bureau Windows Forms développée en C#. Voici les fichiers clés :

-   `CalculatricesInterface.csproj`: Le fichier de projet qui contient les informations de configuration pour le build.
-   `Form1.cs`: Le fichier principal pour la logique de la calculatrice. Il gère les interactions de l'utilisateur et les calculs.
-   `Form1.Designer.cs`: Contient le code généré par le designer pour l'interface utilisateur. Il définit les contrôles (boutons, zones de texte) et leur apparence.
-   `Program.cs`: Le point d'entrée de l'application.

## 2. Fonctionnement du Code

### `Form1.cs`

Ce fichier est le cœur de la calculatrice. Il contient les éléments suivants :

-   **Variables membres** : `currentValue`, `storedValue`, `currentOperation`, `operationPerformed`, et `newCalculation` pour suivre l'état de la calculatrice.
-   **Gestionnaires d'événements** : Des méthodes comme `BtnNumber_Click`, `BtnOperator_Click`, `BtnEquals_Click`, etc., qui répondent aux clics de l'utilisateur.
-   **Logique de calcul** : La méthode `BtnEquals_Click` exécute les calculs en fonction de l'opérateur sélectionné. Les fonctions scientifiques sont gérées dans `BtnScientific_Click`.
-   **Fonctions utilitaires** : Des méthodes comme `Clear`, `ParseDisplay`, et `FormatResult` pour aider à la gestion de l'état et de l'affichage.

### `Form1.Designer.cs`

Ce fichier est généré automatiquement par le designer de Visual Studio et ne doit pas être modifié manuellement. Il contient :

-   **L'initialisation des composants** : La méthode `InitializeComponent` crée et configure tous les contrôles de l'interface utilisateur.
-   **Les propriétés des contrôles** : Les couleurs, les polices, les tailles et les positions de tous les boutons, étiquettes et de la zone d'affichage.

## 3. Comment Exécuter le Projet

Pour compiler et exécuter le projet, vous pouvez utiliser Visual Studio ou MSBuild (l'outil de build de Microsoft).

### Avec Visual Studio

1.  Ouvrez le fichier `CalculatricesInterface.sln` dans Visual Studio.
2.  Cliquez sur le bouton "Démarrer" (ou appuyez sur F5) pour compiler et exécuter l'application.

### En Ligne de Commande (avec MSBuild)

1.  Ouvrez une invite de commande.
2.  Naviguez jusqu'au répertoire du projet.
3.  Trouvez le chemin vers `MSBuild.exe` sur votre système (généralement dans `C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\`).
4.  Exécutez la commande de build :
    ```bash
    "chemin\vers\MSBuild.exe"
    ```
5.  Une fois la compilation réussie, exécutez l'application :
    ```bash
    .\bin\Debug\CalculatricesInterface.exe
    ```
