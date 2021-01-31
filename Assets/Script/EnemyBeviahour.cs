using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyBeviahour : MonoBehaviour
{

    //int detecteson() { } /* retourne 1 dans le plus petit cerle, 2 dans le moyen, 3 dans le grand */
    //void detectebruit() { }
    


    private void Start()
    {

    }

    /* if (runner){
     * if (!isWarning && (detecteBruit() == 3 || detecteBruit() == 2 )){
     *  regarde dans la direction du bruit pendant quelques secondes (15 - 20 secondes)
     *  s'écarte un peu de la zone
     *  isWarning = true
     * }
     * 
     * if(isWarning && (detecteBruit() == 3 || detecteBruit() == 2 )){
     *  isWarning = true
     *  tant que (lePlayer est dans la zone){ 
     *      cours dans la direction opposée du player
     *  si le joueur n'est plus dans la zone {
     *      continue de courir dans l
     *  }
     *  
     * }
     * }
     * 
     * 
     *  if(isWarning){
     *      augmentation de la zone detection de bruit
     *  }
     * 
     * 
     *  Ce qu'il faut :
     *      Un système de zone de détection de bruit composé d'une zone et d'une distance entre l'objet qui écoute et celui qui émet
     *          soit x la distance, entre x et x*0.70 il y a 25% de chance de se faire détecter
     *                              entre x*0.70 et x*0.40 il y a 60% de chance de se faire détecter
     *                              en dessous de x*0.40 il y a 100% de chance de se faire détecter si le second objet emmet, s'il est imobile alors il n'est pas détécté
     *                              
     *                              Lorsqu'il ya marché augmentation ou diminution de la zone de détection, soit ça change les pourcentages, soit ça change la distance (a voir duquel est le plus simple à programmer)
     *                              
     *                              
     *      Un système de vision la vision est de y degrés, et la direction de la vision est défini par un d qui est entre 0 et 360 ce qui représentre tout autour de l'objet
     *          la direction et le degrés de vision seront symbolisés par des barres définissant les limites du champs de vision
     *          Le champs de vision ne peut pas traverser les zones du bushes 
     *              Il faut une méthode permettant de définir la zone à regarder (public)
     *              Il faut une méthode permettant de générer des changements de zones à regarder lors du idle (regarde dans la direction des déplacements)
     * 
     */
}
