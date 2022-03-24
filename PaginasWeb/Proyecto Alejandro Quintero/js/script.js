

function noTerminada(){
    alert("La pagina NO esta terminada, todavia no tenemos carrito de compras")
}

document.getElementById("btn1").addEventListener("click",noTerminada);
document.getElementById("btn2").addEventListener("click",noTerminada);
document.getElementById("btn3").addEventListener("click",noTerminada);
document.getElementById("btn4").addEventListener("click",noTerminada);

document.getElementById("img1").addEventListener("click",noTerminada);
document.getElementById("img2").addEventListener("click",noTerminada);
document.getElementById("img3").addEventListener("click",noTerminada);
document.getElementById("img4").addEventListener("click",noTerminada);
;

/*
var video = document.getElementsByClassName("video")
function playPause(){
    if(video.paused){
        video.play();
    }else{
        video.pause();
    }
}
function detener(){
    video.pause();
    video.currentTime=0;
}
function adelantar(value){
    video.currentTime += value;
}
function retroceder(){

}
*/