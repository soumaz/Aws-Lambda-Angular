resource "aws_security_group" "instancesg" {
  name = "ec2instancesg"
  tags = "${var.tags}"

  ingress {
    cidr_blocks = ["0.0.0.0/0"]
    from_port   = "${var.server_port}"
    to_port     = "${var.server_port}"
    protocol    = "tcp"
    description = "HTTP Transport - General Access Rule"
  }

  ingress {
    cidr_blocks = ["0.0.0.0/0"]
    from_port   = "22"
    to_port     = "22"
    protocol    = "tcp"
    description = "SSH Transport - General Access Rule"
  }

  egress {
    cidr_blocks = ["0.0.0.0/0"]
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    description = "EC2 Instance can connect any Internet URLs"
  }
}
