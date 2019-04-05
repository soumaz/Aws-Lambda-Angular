variable "accessKey" {
  description = "AWS Subscription Access Key"
}

variable "secretKey" {
  description = "AWS Subscription Secret Key"
}

variable "region" {
  description = "Default Region for Resources Deployment"
}

variable "az_count" {
  description = "Number of AZs to cover in a given region"
  default     = "2"
}

variable "app_port" {
  description = "Port exposed by the docker image to redirect traffic to"
  default     = 3000
}

variable "health_check_path" {
  default = "/"
}

variable "connection_string" {}

variable "app_image" {
  description = "Docker image to run in the ECS cluster"
}

variable "fargate_cpu" {
  description = "Fargate instance CPU units to provision (1 vCPU = 1024 CPU units)"
  default     = "1024"
}

variable "fargate_memory" {
  description = "Fargate instance memory to provision (in MiB)"
  default     = "2048"
}

variable "ecs_task_execution_role" {
  description = "ACS Task Execution Role"
}

variable "app_count" {
  description = "Number of docker containers to run"
  default     = 3
}

variable "ecs_autoscale_role" {
  description = "Role arn for the ecsAutocaleRole"
}
