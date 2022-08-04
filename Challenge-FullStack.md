# Indicaciones generales:

- Crea un repositorio en donde se almacenará tu proyecto (github, bitbucket, etc)
- Intenta agrupar funcionalidades en commits individuales, perderás puntos si creas commits grandes sin relación.


# Puntos extras:

- Te daremos puntos extras si realizas el challenge a través de contenedores (docker, kubernetes, etc), es decir, que las herramientas de desarrollo se encuentren en el contenedor, NO en tú máquina (php, node, etc... NO nos referimos al IDE). Puedes usar contenedor directo, o cualquier herramienta que use tu contenedor como núcleo.



# Challenge Back-end

- Puedes utilizar un framework (Laravel, Code Igniter, Visual Studio, etc) o código a elección usando MVC
- Crea 2 tablas para una BD SQL Server, cada una con 3 columnas (sin contar el ID, y los 2 timestamps si usas migraciones, seeders y modelos)
- Crea 2 endpoints de API para cada tabla, el 1ero para toda la colección (todos los datos); eje: api/persona, el 2do para el recurso (un registro en especifico, via su ID); eje: api/persona/1.




# Challenge Front-end

- Puedes utilizar frameworks (react, vue, etc).
- Opcional: crear y levantar un ambiente prototipo.
- Integra estilos de UI (bootstrap, tailwind, etc).
- Usando los elementos UI, crea las siguientes páginas:
- Una página donde haya un buscador de tickets aereos, con los siguientes campos: Ciudad de origen, ciudad de destino, fecha de salida, fecha de retorno.
- Una página donde se muestren resultados de búsqueda de tickets aéreos, cada tarjeta de resultado debería tener: precio, aerolínea, número de escalas, duración del vuelo.
- Los datos deben estar quemados en el store, no pierdas tiempo en esto, pueden ser datos tipo lorem ipsum. No se necesita implementar la funcionalidad de búsqueda.


NOTA: Es muy importante que uses la documentación y trates de apegarte a los estándares de código conocidos, perderás puntos si no respetas la documentación y estándares.