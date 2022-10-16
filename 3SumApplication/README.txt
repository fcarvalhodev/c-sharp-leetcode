Dado um inteiro de array de números, retorne todos os tripletes [nums[i], nums[j], nums[k]]
tal que i != j, i != k, e j != k. E também nums[i] + nums[j] + nums[k] == 0;

Note, a solução não deve conter sets de números duplicados.

Input: nums = [-1,0,1,2,-1,-4]
Output: [[-1,-1,2],[-1,0,1]]
Explicação: 
nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
Os triplets distinto são: [-1,0,1] e [-1,-1,2].
Observação: A ordem do output e a ordem dos tripletes não deve ser considerada.
