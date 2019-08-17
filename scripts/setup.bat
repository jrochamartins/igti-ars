# Install and run

# MongoDb
docker run --name pa-ars-mongo -p 27017:27017 -d mongo

#RabbitMq
docker run -d --hostname pa-ars-rabbit --name pa-ars-rabbit -p 5672:5672 rabbitmq:3