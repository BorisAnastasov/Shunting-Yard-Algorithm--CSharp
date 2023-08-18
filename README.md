### Shunting Yard Algorithm
The Shunting Yard Algorithm is a method for parsing arithmetical or logical expressions, or a combination of both, specified in infix notation. It can produce a postfix notation string, also known as Reverse Polish notation.


###Example
<p>
                                        Input: <span class="nowrap">3 + 4 × 2 ÷ ( 1 − 5 ) ^ 2 ^ 3</span>
                                    </p>
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
