data "template_file" "userdata" {
  template = "./templates/user-data.txt.tpl"

  vars {
    server_port = "${var.server_port}"
  }
}
