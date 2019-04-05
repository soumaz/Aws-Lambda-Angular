variable "accessKey" {}

variable "secretKey" {}

variable "region" {
  default = "ap-south-1"
}

variable "server_port" {}
variable "key_name" {}

variable "tags" {
  type    = "map"
}
