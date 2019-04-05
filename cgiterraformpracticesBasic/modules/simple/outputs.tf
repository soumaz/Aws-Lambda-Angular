output "instance_dns" {
  value = "${aws_instance.simple.public_dns}"
}

output "instance_public_ip" {
  value = "${aws_instance.simple.public_ip}"
}
