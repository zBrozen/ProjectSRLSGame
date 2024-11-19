# ProjectSRLSGames
Développement d'un premier jeu sous Unity qui constituera différents genres: le shooter/shmup, rogue lite, et survivor.

---

# Table des matières:
1. [Les Concepts](#les-concepts)
2. [Le Gameplay](#le-gameplay)
3. [Les statistiques](#les-statistiques)
4. [Les idées d'ennemis](#les-idées-dennemis)
5. [Idées essentielles](#idées-essentielles)
6. [Idées bonus](#idées-bonus)


# Les Concept
  Rogue like proposant des niveaux avec un système de vague. Il existera une variété de personnages avec des compétences différentes (corps à corps, distance, tourelles par ex). Chaque vague est illustrée dans un tableau (carte de la vague) qui comportera des éléments de blocages comme des murs ou des pièges.

## Inspirations :
  Nier Automata, Sonic Frontier, Hades, Enter the Gungeon, Brotato, Warframe
 
## DA du jeu :
  Sur Unity, faire de la 2D/3D, càd un mélange avec les mécaniques 2D dans un monde 3D, qui reprendra le style des niveaux d’hacking dans NieR Automata ou quelque chose de simpliste du même genre.

## Personnage :
  Le personnage basique serait une flèche blanche comme dans NieR, mais qui aura quelques variances de formes comme : une complexité dans le dessin de la flèche pour la puissance, une couleur différente selon le type de jeu, ou des armes en plus qui peuvent l’accompagner.

---

# Le Gameplay :
  En face il y aura des ennemis de différentes sortes comme pour le joueur, mais globalement ça serait des ennemis qui peuvent tirer des projectiles.
  
## Projectiles :
Le joueur et les ennemis ont des projectiles différents qui peuvent s’annuler entre eux (par ex : projectile blanc s’annule avec un projectile de cette même couleur, ou un projectile puissant s’annule quand sa barre de vie tombe à 0)

## Mêlée :
Généralement une lame qui peut être donnée au joueur ou aux ennemis. Cette lame inflige plus de dégâts que les projectiles mais elle peut être parée (contre ou autre mécanique de défense).

## Mécanique de rogue like :
  Le joueur pourra, après avoir passé un certain nombre de vague, arriver dans une boutique où il dépensera son argent/utiliser des points pour débloquer des compétences et des armes.

## Les compétences :
Mécanique de déplacement, amélioration de stats, des passifs et des actifs. Les compétences seront la plupart du temps utilisées pour une run, tandis que d’autres peuvent se débloquer au fil des runs terminées (personnages débloqués à la fin d’une run avec un set de départ de compétences).

## Les armes :
Peuvent améliorer les stats de dégâts, changer la façon d’attaquer (manière de tirer ou combo en mêlée). Les armes peuvent être uniques à un run ou changeable, à voir. Pour chaque arme, il serait possible de les améliorer une par une au fil des runs avec des objets rares (comme pour Hades avec son sang de Titan). Donc ça permettra de rendre plus simple l’avancée dans les niveaux plus compliqués.

## Les défis (inspiré un peu d’Hades) :
Permet de réaliser certaines runs de manières plus compliqués avec des restrictions. Il existe différents aspects à exploiter comme : le nombre d’ennemis par vague qui vont accentuer la longueur des vagues, mais on peut aussi augmenter les ennemis difficiles à battre ou agir sur la façon de jouer du personnage (retire la possibilité de parer avec des items ou des couleurs).
Sera obligatoire ou non, mais permettra d’utiliser les mécaniques d’amélioration entre les runs.

---

# Les Statistiques

## Personnage :
o	HP : barre de vie ou couleur qui change ou DA qui change (coin plus sombre et rouge)
o	Défense : capacité à encaisser les dégâts, boucliers (barre de bouclier, points de bouclier comme dans Sonic, aspect physique du perso comme dans NieR)
o	Vitesse : capacité à se déplacer plus ou moins vite
o	Esquive : capacité à réussir une esquive de coup ou de projectile
o	Régénération de la vie : permet de régénérer de la vie au bout d’un certain temps
o	Vitesse de régénération : facteur influent la régénération
o	Niveau : influe sur toutes les statistiques

## Armes :
o	Dégâts : stat de base qui inflige un montant de dégâts sur la vie
o	Dégâts perforants : dégâts qui affectent la défense
o	Dégâts critiques : taux qui affecte tous les types de dégâts
o	Chance critique : taux qui affecte la possibilité qu’un dégât soit critique.
o	Vitesse d’attaque (de coup ou de tir) : influe la vitesse avec laquelle le personnage peut attaquer
o	Vol de vie : taux de régénération de la vie à partir des dégâts effectués sur les ennemis
o	Chance vol de vie : taux de chance permettant de définir si un dégât applique le vol de vie
o	Couleur : affecte certains coup ou projectiles pour effectuer un contre
o	Perforation : taux de chance qui permettrait d’ignorer le bouclier
o	Rang : influe sur toutes les statistiques

## Ennemis :
o	HP : varie selon le type d’ennemis (sbires, spéciaux, boss)
o	Défense : varie selon le type d’ennemis
o	Vitesse : généralement plus lente que le joueur, mais peut varier
o	Classe : défini l’appartenance à une famille/groupe, ce qui affecte ses armes et son comportement.
o	Rang : influe sur toutes les statistiques.

## Classes d’ennemis :
  Il existe différents types d’ennemis qui seront tous plus ou moins commun. Par exemple il y a l’ennemi de base qui aura une arme à feu et qui restera à distance, mais il peut avoir différentes améliorations comme son arme et ses stats. Ces améliorations s’effectuent au fil des vagues pour améliorer la difficulté du jeu.

---

# Les idées d’ennemis
## Le sbire :
Ennemi commun, arme de tir basique (sans couleur précise, donc parade facile), essaye de ne pas trop s’approcher du joueur pour lui tirer dessus sans craintes.
Améliorations possibles : rang (santé et défense), armes de tir plus puissante, ajout de couleur.

## Le kamikaze :
Ennemi sans arme, portant une bombe et ayant comme seul objectif de foncer sur le joueur. Lorsque le joueur le tue, il explose sur les ennemis alentours. Sa portée d’explosion évolue selon le rang de cet ennemi.
Améliorations possibles : rang (santé, défense, vitesse), bombe.

## Le bombardier :
Ennemi avec un lance grenade (sans couleur précise), effectuant une AOE lorsqu’il tire. Il est plus lent que le kamikaze mais il est capable de tirer à distance en se cachant le plus possible du joueur (équivalent des pots qui balancent des mini bombes dans Hades).
Améliorations possibles : rang (santé, défense, vitesse), son lance grenade, ajout de couleur.

## Le guerrier :
Ennemi avec une arme de mêlée (sans couleur précise) qui va chercher le joueur au corps à corps. Soit il donne des coups avec des combo, soit il fonce juste sur le joueur pour l’attaquer.
Améliorations possibles : rang (santé, défense), son arme, ajout de couleur.

---

# Idées essentielles

# Idées bonus
