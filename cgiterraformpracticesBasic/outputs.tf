output "dns" {
  value = "${module.simple.instance_dns}"
}

output "publicip" {
  value = "${module.simple.instance_public_ip}"
}
