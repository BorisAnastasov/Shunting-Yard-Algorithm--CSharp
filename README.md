### Shunting Yard Algorithm
The Shunting Yard Algorithm is a method for parsing arithmetical or logical expressions, or a combination of both, specified in infix notation. It can produce a postfix notation string, also known as Reverse Polish notation.

### What are the rules?

<dl>
                                        <dd>
                                            <table class="wikitable">
                                                <tbody>
                                                    <tr>
                                                        <th>Operator</th>
                                                        <th>Precedence</th>
                                                        <th>Associativity
</th>
                                                    </tr>
                                                    <tr align="center">
                                                        <td>^</td>
                                                        <td>4</td>
                                                        <td>Right
</td>
                                                    </tr>
                                                    <tr align="center">
                                                        <td>×</td>
                                                        <td>3</td>
                                                        <td>Left
</td>
                                                    </tr>
                                                    <tr align="center">
                                                        <td>÷</td>
                                                        <td>3</td>
                                                        <td>Left
</td>
                                                    </tr>
                                                    <tr align="center">
                                                        <td>+</td>
                                                        <td>2</td>
                                                        <td>Left
</td>
                                                    </tr>
                                                    <tr align="center">
                                                        <td>−</td>
                                                        <td>2</td>
                                                        <td>Left
</td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </dd>
                                    </dl>
                                    <p>

### What is the main logic?
```
  While there are tokens to be read:
       Read a token
        ->If it's a number add it to queue
        ->If it's an operator
               While there's an operator on the top of the stack with greater precedence:
                       Pop operators from the stack onto the output queue
               Push the current operator onto the stack
        ->If it's a left bracket push it onto the stack
        ->If it's a right bracket 
            While there's not a left bracket at the top of the stack:
                     Pop operators from the stack onto the output queue.
             Pop the left bracket from the stack and discard it
 While there are operators on the stack, pop them to the queue
```

### Example
<p>
                                        Input: <span class="nowrap">3 + 4 × 2 ÷ ( 1 − 5 ) ^ 2 ^ 3</span>
                                    </p>
                                    
<dl>
                                        <dd>
                                            <table class="wikitable">
                                                <tbody>
                                                    <tr>
                                                        <th>Token</th>
                                                        <th>Action</th>
                                                        <th>
                                                            Output<br/>
                                                            (in <a href="/wiki/Reverse_Polish_Notation" class="mw-redirect" title="Reverse Polish Notation">RPN</a>
                                                            )
                                                        </th>
                                                        <th>
                                                            Operator<br/>stack
                                                        </th>
                                                        <th>Notes
</th>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">3</td>
                                                        <td>Add token to output</td>
                                                        <td>3</td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">+</td>
                                                        <td>Push token to stack</td>
                                                        <td>3</td>
                                                        <td align="right">+</td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">4</td>
                                                        <td>Add token to output</td>
                                                        <td>3 4</td>
                                                        <td align="right">+</td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">×</td>
                                                        <td>Push token to stack</td>
                                                        <td>3 4</td>
                                                        <td align="right">× +</td>
                                                        <td>× has higher precedence than +
</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">2</td>
                                                        <td>Add token to output</td>
                                                        <td>3 4 2</td>
                                                        <td align="right">× +</td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" rowspan="2">÷</td>
                                                        <td>Pop stack to output</td>
                                                        <td>3 4 2 ×</td>
                                                        <td align="right">+</td>
                                                        <td>÷ and × have same precedence
</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Push token to stack</td>
                                                        <td>3 4 2 ×</td>
                                                        <td align="right">÷ +</td>
                                                        <td>÷ has higher precedence than +
</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">(</td>
                                                        <td>Push token to stack</td>
                                                        <td>3 4 2 ×</td>
                                                        <td align="right">( ÷ +</td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">1</td>
                                                        <td>Add token to output</td>
                                                        <td>3 4 2 × 1</td>
                                                        <td align="right">( ÷ +</td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">−</td>
                                                        <td>Push token to stack</td>
                                                        <td>3 4 2 × 1</td>
                                                        <td align="right">− ( ÷ +</td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">5</td>
                                                        <td>Add token to output</td>
                                                        <td>3 4 2 × 1 5</td>
                                                        <td align="right">− ( ÷ +</td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" rowspan="2">)</td>
                                                        <td>Pop stack to output</td>
                                                        <td>3 4 2 × 1 5 −</td>
                                                        <td align="right">( ÷ +</td>
                                                        <td>Repeated until "(" found
</td>
                                                    </tr>
                                                    <tr>
                                                        <td>Pop stack</td>
                                                        <td>3 4 2 × 1 5 −</td>
                                                        <td align="right">÷ +</td>
                                                        <td>Discard matching parenthesis
</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">^</td>
                                                        <td>Push token to stack</td>
                                                        <td>3 4 2 × 1 5 −</td>
                                                        <td align="right">^ ÷ +</td>
                                                        <td>^ has higher precedence than ÷
</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">2</td>
                                                        <td>Add token to output</td>
                                                        <td>3 4 2 × 1 5 − 2</td>
                                                        <td align="right">^ ÷ +</td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">^</td>
                                                        <td>Push token to stack</td>
                                                        <td>3 4 2 × 1 5 − 2</td>
                                                        <td align="right">^ ^ ÷ +</td>
                                                        <td>^ is evaluated right-to-left
</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">3</td>
                                                        <td>Add token to output</td>
                                                        <td>3 4 2 × 1 5 − 2 3</td>
                                                        <td align="right">^ ^ ÷ +</td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <i>end</i>
                                                        </td>
                                                        <td>Pop entire stack to output</td>
                                                        <td>3 4 2 × 1 5 − 2 3 ^ ^ ÷ +</td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </dd>
                                    </dl>
