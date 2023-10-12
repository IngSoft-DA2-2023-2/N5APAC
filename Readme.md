Pregunta: Cómo registraron la dependencia del ejercicio anterior? Por qué eligieron esa forma de registrarlo?

Para inyectar el IStudentLogic en el Program.cs se selecciono el tiempo de vida "Scoped".
Se opto por la misma para que la instancia del servicio esté disponible durante toda la duración de una solicitud HTTP. Cada solicitud recibirá una nueva instancia del servicio.

Las otras 2 opciones podrían ser Singleton o Transient.
No se opto por Singleton ya que no veo necesario que se cargue una vez y se utiliza en toda la aplicación.
Y Transient tampoco ya que el sería util si fuese un servicio temporal que realiza una tarea específica y no necesita mantener ningún estado global.


