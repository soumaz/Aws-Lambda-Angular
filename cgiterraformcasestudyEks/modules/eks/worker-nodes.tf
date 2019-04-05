resource "aws_autoscaling_group" "eks" {
  desired_capacity     = "${var.desired-capacity}"
  launch_configuration = "${aws_launch_configuration.eks.id}"
  max_size             = "${var.max-size}"
  min_size             = "${var.min-size}"
  name                 = "${var.cluster-name}-eks-asg"
  vpc_zone_identifier  = ["${aws_subnet.eks.*.id}"]

  tag {
    key                 = "Name"
    value               = "${var.cluster-name}-eks-node"
    propagate_at_launch = true
  }

  tag {
    key                 = "kubernetes.io/cluster/${var.cluster-name}"
    value               = "owned"
    propagate_at_launch = true
  }
}
