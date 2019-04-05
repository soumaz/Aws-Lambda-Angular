#!/bin/bash
echo "hello"

sudo apt-get update

curl --ssl https://get.docker.com | sudo bash -E -

sudo usermod -aG docker ubuntu