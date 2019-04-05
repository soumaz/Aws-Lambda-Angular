data "template_file" "cb_app" {
  template = "${file("./templates/ecs-fg-task.json.tpl")}"

  vars {
    app_image         = "${var.app_image}"
    fargate_cpu       = "${var.fargate_cpu}"
    fargate_memory    = "${var.fargate_memory}"
    aws_region        = "${var.region}"
    app_port          = "${var.app_port}"
    connection_string = "${var.connection_string}"
  }
}
