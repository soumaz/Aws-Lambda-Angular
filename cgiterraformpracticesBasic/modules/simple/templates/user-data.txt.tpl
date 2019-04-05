#!/bin/bash
echo "Hello to Terraform Modules!" > index.html
nohup busybox httpd -f -p ${server_port} &