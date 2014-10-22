<?php
echo '<!DOCTYPE html>
<html>
<head>
	<link rel="shortcut icon" href="../img/favicon.png" type="image/png">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>English-5000</title>
	<link rel="stylesheet" href="../css/main.css" type="text/css" />
</head>
<body>
<div id="container">
		<div id="header">
		</div>

		<div id="navigation">
			<a href="/" class="rollover1"></a>
			&nbsp;&nbsp;&nbsp;&nbsp;
			<a href="/users" class="rollover2"></a>
			&nbsp;&nbsp;&nbsp;&nbsp;
			<a href="/reg" class="rollover3"></a>
			&nbsp;&nbsp;&nbsp;&nbsp;
			<a href="/download" class="rollover4"></a>
			&nbsp;&nbsp;&nbsp;&nbsp;
			<a href="/about" class="rollover5"></a>
		</div>
		
		<div id="content">';
		
echo '<table>
	<tr>
		<b>
		<td>Номер</td>
		<td>Пользователь</td>
		<td>Регистрация</td>
		<td>Входов</td>
		</b>
	</tr>';
$dbh = new PDO('sqlite:data.db3') or die("cannot open the database");
$query =  "SELECT * from Users";
foreach ($dbh->query($query) as $row)
{
	echo '<tr>';
	echo '<td>';
	echo $row[0];
	echo '</td><td>';
	echo $row[1];
	echo '</td><td>';
	echo $row[3];
	echo '</td><td>';
	echo $row[4];
	echo '</td></tr>';
}
	// Запишем что-нибудь в таблицу 
	//sqlite_query($db, "INSERT INTO table1(field1, field2) VALUES ('PHP5+', 'Apache');");
echo '</table>';
	
	
echo '
		</div>

		<div class="hFooter">
		</div>
	</div>
	
	<div id="footer">
		<div id="text">
			<br><br>
			Идея и разработка - <a href="http://vk.com/re5665tm">Караваев Вадим</a>
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			&copy;2013 <a href="http://cat.exlain.ru">cat.exlain.ru</a>
		</div>
	</div>

</body>
</html>';
?>