<?php
session_start();
ob_start();
$k_adi=$_POST("kullanici_adi");
$sifre=$_POST("kullanici_adi");
include("baglanti.php");
$sql="select*from kullanici where kullanici_adi='$k_adi' and sifre='$sifre'";
$sorgu=mysql_query($sql,$bagno);
$kontrol=0;
$uye=0;
while($kullanici=mysql_fetch_array($sorgu))
{
	$kontrol++;
	$uye=$kullanici[0];
    $_SESSION["site"]="yasinozdemir.com";
    $_SESSION["id"]=$uye;
   header ("Location:index1.php?kid=$uye");
}
if ($kontrol==0) header ("Location:index.php.html");
?>