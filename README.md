# Ways

Plateforme permettant d'orienter les candidats et de mieux les connaître lors des JPO du CESI.
Développement d'une dimension "jeu", d'une dimension "orientation" et d'un espace d'administration.

# Tuto Git
1. Télécharger Git. Pour Windows, c'est là : https://gitforwindows.org/
2. Cloner un dépôt (ou repository).
- Se positionner dans le dossier souhaité. Par exemple C:\Users\chris\source\repos
- Ouvrir un terminal et exécuter : git clone https://github.com/IAMCHRISC/Ways.git
- Un nouveau répertoire est créé contenant le projet. S'y positionner en exécutant : cd ways
3. Créer une nouvelle branche. Pour l'exemple, elle s'appelle ici "dev_val".
- Dans le terminal, exécuter : git checkout -b dev_val
- Cette branche n'est pas disponible tant qu'elle n'a pas été envoyée sur le dépôt distant.
- Pour ce faire, exécuter : git push origin dev_val
- Pour savoir sur quelle branche on se trouve (pratique quand il y en a plusieurs), exécuter : git branch
4. Ajouter, valider et envoyer des changements.
- Pour ajouter un fichier, exécuter : git add *nom_du_fichier*
- Pour ajouter plusieurs fichiers, exécuter : git add .
- Pour valider ces changements, exécuter : git commit -m "Message de validation"
- Pour envoyer ces changements sur le dépôt distant, exécuter : git push origin *nom_de_la_branche*
    - Ex : git push origin dev_val
5. Mettre à jour des changements.
- Pour mettre à jour son dépôt local avec les dernières modifications, exécuter : git pull
- Cela va récupérer et fusionner les changements effectués par quelqu'un d'autre.
6. Lien vers le tuto d'origine : https://rogerdudler.github.io/git-guide/index.fr.html
