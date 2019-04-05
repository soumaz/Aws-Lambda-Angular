resource "aws_instance" "simple" {
  ami                    = "ami-54d2a63b"
  instance_type          = "t2.micro"
  key_name               = "${var.key_name}"
  vpc_security_group_ids = ["${aws_security_group.instancesg.id}"]
  tags                   = "${var.tags}"
  user_data              = "${data.template_file.userdata.rendered}"
}
