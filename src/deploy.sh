#!/bin/bash

rm -rf /home/matheo/ticketool/src/out

dotnet clean

dotnet publish -c Release -o out

# Redémarrer le service pour appliquer les modifications
sudo systemctl restart ticketool