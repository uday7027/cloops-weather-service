#!/usr/bin/env bash
# usage: ./nats/health.sh
nats request health.WeatherService hello | jq

