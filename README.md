<h1 align="center">
  <img src="https://github.com/claudio-familia/WalletPlanifier-mobile/blob/master/wallet-planning.png" width="100%"/><br/>
</h1>

<p>
  <b>The Wallet Plannifier</b> Es un servicio web que pretende ser la aplicación que se encargue de la gestión de la logica de la aplicación mobil asi como ser eje central para la seguridad de los datos de los usuarios.    
</p>
<p>
  El software está siendo desarrollado en .NET Core 3.1, utilizando una base de datos con MySQL con una arquitectura de cebolla.
</p>

<h2>Arquitecture (Arquitectura)</h2>
<ul>
  <h3>Onion arquitecture</h3>
  <p>
  La arquitectura de cebolla o onion architecture es un patrón arquitectónico que permite sistemas empresariales evolutivos y mantenibles. Está diseñado para ser usado a nivel de capas, las cuales mantienen la aplicación desacoplada, testeable y mantenible garantizando la simpleza sin perder escalabilidad
  </p>
  <h3>Test driven development</h3>  
  <p>
  Desarrollo guiado por pruebas de software, o Test-driven development (TDD) es una práctica de ingeniería de software que involucra otras dos prácticas: Escribir las pruebas primero (Test First Development) y Refactorización (Refactoring). Para escribir las pruebas generalmente se utilizan las pruebas unitarias (unit test en inglés)
  </p>
</ul>

<h2>Environtment (Ambientes)</h2>
<ul>
  <h3>Heroku</h3>
  <p>
    El ambiente de publicación que estamos utilizando es hosteado en heroku. Heroku es una plataforma como servicio (PaaS) de computación en la Nube que soporta distintos lenguajes de programación. Nuestra aplicacion es hospedada allí gracias a que la tenemos en un contenedor de docker.
  </p>
  <h3>Docker</h3>
  <p>
    Docker es un proyecto de código abierto que automatiza el despliegue de aplicaciones dentro de contenedores de software, proporcionando una capa adicional de abstracción y automatización de virtualización de aplicaciones en múltiples sistemas operativos
  </p>
  <h3>Continous Delivery</h3>
  <p>
   El proyecto es publicado por medio a lo que se conoce como continous delivery o deployment, lo cual consiste en un enfoque de la ingeniería del software en que los equipos de desarrollo producen software en ciclos cortos, asegurando que el software puede ser liberado en cualquier momento, de forma confiable en cualquier momento
  </p>
</ul>

<h2>Security (Seguridad)</h2>
<ul>
  <h3>Json web tokens</h3> 
  <p>
    La aplicación cuenta con una seguridad utilizando lo que es Json web tokens que es un estándar abierto basado en JSON propuesto por IETF (RFC 7519) para la creación de tokens de acceso que permiten la propagación de identidad y privilegios o claims en inglés. Por ejemplo, un servidor podría generar un token indicando que el usuario tiene privilegios de administrador y proporcionarlo a un cliente.
  <p>
</ul>

<h2>Data persistency (Persistencia de datos)</h2>
<ul>
  <h3>MySQL</h3> 
  <p>
    La persistencia de datos en la aplicación la manejamos utiliznado el gestor de bases de datos MySQL el cual es un sistema de gestión de bases de datos relacional desarrollado bajo licencia dual; una de las más populares en general junto a Oracle y Microsoft SQL Server, todo para entornos de desarrollo web. El servicio lo utilizamos a traves de Jaws que es ofrecido por heroku.
  </p>
  
</ul>
